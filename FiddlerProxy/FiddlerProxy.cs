using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FiddlerProxy
{
    public class FiddlerProxy : MelonMod
    {
        public override void OnApplicationStart()
		{
            Patches.Init(HarmonyInstance);
        }
    }
}
