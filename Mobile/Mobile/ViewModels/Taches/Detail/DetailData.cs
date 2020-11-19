using System.Collections.Generic;
using System.Collections.ObjectModel;
using Models.Dtos.Locataires;
using Models.Dtos.Taches;

namespace Mobile.ViewModels.Taches.Detail
{
	public class DetailData : BaseViewModel
	{
		private TacheReadDto _tache;

		public ObservableCollection<LocataireReadDto> Locataires { get; set; } // données bindée dans la dgv du Fournisseur sélectionné
		public ObservableCollection<LocataireInclu> LocataireIncluded { get; set; }

		public TacheReadDto Tache
		{
			get => _tache;
			set => SetProperty(ref _tache, value);
		}

		public class LocataireInclu : BaseViewModel
		{
			private int _idLocataire;
			private bool _inclu;

			public int IdLocataire
			{
				get => _idLocataire;
				set => SetProperty(ref _idLocataire, value);
			}

			public bool Inclu
			{
				get => _inclu;
				set => SetProperty(ref _inclu, value);
			}
		}
	}
}
