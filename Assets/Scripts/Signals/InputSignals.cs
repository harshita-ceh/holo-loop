﻿using Enums;
using Extentions;
using UnityEngine.Events;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction<PlayerState> onInputTaken = delegate {  };
    }
}