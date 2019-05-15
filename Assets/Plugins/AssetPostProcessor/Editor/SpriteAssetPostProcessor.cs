using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

namespace CraftingLegends.SceneTools
{
	public class SpriteAssetPostProcessor : AssetPostprocessor
	{
		private const float PIXEL_PER_UNIT = 16f;

		// called the first time a sprite is created etc.
		// not called when only pixels were changed
		private void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
		{
			TextureImporter importer = assetImporter as TextureImporter;

			// we only change sprite import settings on first import, so we can change those settings for individual files
			string name = importer.assetPath.ToLower();

			if (File.Exists(AssetDatabase.GetTextMetaFilePathFromAssetPath(name)))
			{
				return;
			}

			// adjust values for pixel art

			importer.spritePixelsPerUnit = PIXEL_PER_UNIT;
			importer.mipmapEnabled = false;
			importer.filterMode = FilterMode.Point;
			importer.textureCompression = TextureImporterCompression.Uncompressed;

			importer.textureType = TextureImporterType.Sprite;
			//importer.textureType = TextureImporterType.Advanced;
			//importer.isReadable = true;

			// access the TextureImporterSettings to change the spriteAlignment value

			TextureImporterSettings textureSettings = new TextureImporterSettings();
			importer.ReadTextureSettings(textureSettings);

			textureSettings.spritePivot = new Vector2(0.5f, 0f);
			textureSettings.spriteAlignment = (int)SpriteAlignment.BottomCenter;
			textureSettings.spriteMeshType = SpriteMeshType.FullRect;

			importer.SetTextureSettings(textureSettings);

			importer.SaveAndReimport();
		}
	}
}