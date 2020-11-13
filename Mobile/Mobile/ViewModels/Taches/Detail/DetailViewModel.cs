﻿using System;
using System.Diagnostics;
using Models.Dtos.Taches;
using RestApiClient.Controllers;
using Xamarin.Forms;

namespace Mobile.ViewModels.Taches.Detail
{
	[QueryProperty(nameof(TacheId), nameof(TacheId))]
	public class DetailViewModel : BaseViewModel
	{
		private DetailData _detailData;
		private string _itemId;
		private readonly TachesController _taches = new TachesController();

		public DetailViewModel()
		{
			Title = "Création d'une tâche";
		}

		public DetailData Tache
		{
			get => _detailData;
			set => SetProperty(ref _detailData, value);
		}

		public string TacheId
		{
			get => _itemId;
			set
			{
				_itemId = value;
				LoadItemId(value);
			}
		}

		public async void LoadItemId(string itemId)
		{
			try
			{
				Tache.Tache = await _taches.GetById<TacheReadDto>(Convert.ToInt32(itemId));
			}
			catch (Exception)
			{
				Debug.WriteLine("Impossible de charger la tâche avec l'id : " + itemId);
			}
		}
	}
}
