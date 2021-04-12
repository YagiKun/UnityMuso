Shader "Unlit/TestShader"
{
	//マテリアルで設定したいプロパティ
    /*
	浮動小数点数
	_Float("Float", float) = 0.1

	整数
	_Int("Int", int) = 5

	スライダーで設定
	_Range("Range", Range(0.5, 1.0)) = 0.75

	色
	_Color("Color", Color) = (1, 0, 0, 1)
	*/
	Properties
    {
		//[NoScaleOffset] でTilling,Offsetが不要に
        _MainTex ("Texture", 2D) = "black" {}
    }
	//シェーダーの中身、複数書ける
	//上から順に実行できるShaderを探し、見つからない場合 FallBack off を記述(offは自由、別の場合もあり)
    SubShader
    {
		//UnityにShaderの設定を伝えるためにタグが必要
        //改行により複数書ける、";"はいらない
		/*
		RenderType
		シェーダーがどのグループに属しているのかを指定する
		Transparent		半透明
		Opaque			それ以外
		*/
		Tags { "RenderType"="Opaque" }
        //Lavel of Detail	しきい値
		//ゲームのグラフィック品質に合わせてシェーダーを切り替えるなど
		//得には使わん
		LOD 100

		//固定機能シェーダ
		//サーフェスシェーダ
		//頂点フラグメントシェーダ
		//のいずれかを指定
		/*
		頂点フラグメントシェーダについて
		Unityでは三角形でポリゴンの描画
		3つの頂点の情報が渡される、そのために座標変換をする(ワールド → スクリーン)
		フラグメントシェーダ...画面に描画する色を指定
		*/
        Pass
        {
			//Cg言語を使用
			//CGPROGRAM ～ ENDCG
            CGPROGRAM
            #pragma vertex vert			//頂点シェーダ関数名
            #pragma fragment frag		//フラグメントシェーダ関数名
            // make fog work
            #pragma multi_compile_fog	//シェーダバリアント使用
										//FOG → フォグ、億に行くほど色がつくような表現ができる
										//しかし、チェックボックスを入れないと動作しないため、オン、オフを自動で切り替えてくれる
												
            #include "UnityCG.cginc"

			//頂点シェーダへの入力定義
            struct appdata
            {
				/*
				セマンティクス
				POSITION	頂点座標(float3~4)
				TEXCOORDn	n番目のテクスチャUV
				NORMAL		頂点の法線(float3)
				TANGENT		接戦(float4)
				COLOR		頂点カラー(float4)
				
				対象のシェーダーで必要な物を受け取る際に使用
				*/

                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

			//フラグメントシェーダへ渡すデータ
			//ラスタライザに渡されて、補完された値がフラグメントシェーダに渡される
            struct v2f
            {
				/*
				セマンティクス
				SV_POSITION	座標変換された後の頂点座標
				TEXCOORDn	テクスチャUVなど
				COLORn		色など
				*/
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;		//上記で設定した値を渡している?
            float4 _MainTex_ST;		//float4 = Vector4
									//_STはインスペクタで表示する部分
									//x,y,z,wに格納される

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
