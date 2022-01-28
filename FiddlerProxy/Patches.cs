using BestHTTP;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FiddlerProxy
{
	internal static class Patches
	{
		private static HarmonyLib.HarmonyMethod GetPatch(String name)
		{
			return new HarmonyLib.HarmonyMethod(typeof(Patches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
		}

		public static void Init(HarmonyLib.Harmony harmonyInstance)
		{
			harmonyInstance.Patch(typeof(HTTPRequest).GetMethod(nameof(HTTPRequest.Send)), prefix: GetPatch(nameof(Patches.SendPatch)));
		}

		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		private static void SendPatch(ref HTTPRequest __instance)
		{
			__instance.Proxy = new HTTPProxy(new Il2CppSystem.Uri("http://127.0.0.1:8888/"));
		}
	}
}
