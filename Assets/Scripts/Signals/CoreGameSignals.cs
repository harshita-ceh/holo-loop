﻿using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onPlay = delegate {  };
        public UnityAction onReset = delegate {  };
        public UnityAction onGainPlayerScore = delegate {  };
        public UnityAction onGainEnemyScore = delegate {  };
        public UnityAction<GameState> onChangeGameState = delegate {  };
    }
}