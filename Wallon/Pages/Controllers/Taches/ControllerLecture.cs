using System.Drawing;
using System.Threading.Tasks;
using AutoMapper;
using FlatControls.Controls;
using Models.Dtos.Taches;
using Wallon.Repository;

namespace Wallon.Pages.Controllers.Taches
{
	public class ControllerLecture
	{
		private readonly RepositoryTaches _repositoryTaches = RepositoryTaches.Instance;

		private TacheReadDto _tacheReadDto;

		public TacheReadDto Tache => _tacheReadDto;

		public async Task Hydrate(int idTache)
		{
			_tacheReadDto = await _repositoryTaches.LireId(idTache);
		}

		public void SetSizeTextField(FlatTextBox flatTextBoxDescription)
		{
			flatTextBoxDescription.SizeTextField = new Size(flatTextBoxDescription.Width - 50, flatTextBoxDescription.Height - 50);
		}

		public async Task Modifier(string text)
		{
			var config = new MapperConfiguration(cfg => cfg.CreateMap<TacheReadDto, TacheUpdateDto>());
			var mapper = new Mapper(config);
			TacheUpdateDto tacheUpdateDto = mapper.Map<TacheUpdateDto>(_tacheReadDto);

			tacheUpdateDto.Description = text;

			await _repositoryTaches.Modifier(tacheUpdateDto);
		}
	}
}
