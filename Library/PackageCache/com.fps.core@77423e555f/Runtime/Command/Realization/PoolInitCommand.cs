#if FPS_POOL 
using System;
using FPS.Pool;
using UnityEngine;

namespace FPS
{
    public class PoolInitCommand : SyncCommand
    {
        public override void Do()
        {
            try
            {
                FluffyPool.Init(RuntimeDispatcher.CancellationToken);
                Status = CommandStatus.Success;
            }
            catch (Exception e)
            {
                Status = CommandStatus.Error;
                Debug.LogError(e);
            }
        }
    }
}

#endif