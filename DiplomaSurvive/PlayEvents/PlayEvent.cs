﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class PlayEvent : ActionPage
    {
        public virtual bool IsAvailable (BaseContext context = null)
        {
            return true;
        }
    }
}
