using System.Collections.Generic;
using System.Collections.ObjectModel;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;

namespace Mobile.ViewModels.Taches.Detail
{
	public class DetailData : BaseViewModel
	{
		private TacheReadDto _tache;

		//public ObservableCollection<LocataireReadDto> Locataires { get; set; } // données bindée dans la dgv du Fournisseur sélectionné
		public ObservableCollection<LocatairesInclus> Locataires { get; set; }

		public TacheReadDto Tache
		{
			get => _tache;
			set => SetProperty(ref _tache, value);
		}

		public class LocatairesInclus : BaseViewModel
		{
			private LocataireReadDto _locataire;
			private bool _inclu;

			public bool Inclu
			{
				get => _inclu;
				set => SetProperty(ref _inclu, value);
			}

			public LocataireReadDto Locataire
			{
				get => _locataire;
				set => SetProperty(ref _locataire, value);
			}
		}
	}
}
