using Commands;
using Common;
using FPS;
using FPS.Sheets;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECS.Systems
{
	public class AppInitSystem : IEcsInitSystem
	{
		private EcsCustomInject<DTOStorage> _dtoStorage;

		public void Init(IEcsSystems systems)
		{
			new GameObject(nameof(RuntimeDispatcher)).AddComponent<RuntimeDispatcher>().Init();

			var queue = new CommandQueue();
			BaseCommands.Insert(queue);
			SheetCommands.Insert(queue, new SheetsApi(_dtoStorage.Value));


			//add other commands
			queue.Enqueue(new ShowUIRootCommand(systems.GetWorld()));


			queue.Enqueue(new HideLoaderCommand(queue));
			queue.Execute().Forget();
		}
	}
}