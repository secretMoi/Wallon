﻿namespace Packager.Hash
{
	public interface IHash
	{
		public string FileName { get; set; }

		public string HashFile();
	}
}
