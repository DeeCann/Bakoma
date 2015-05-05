
using UnityEngine;
using System;
using System.Collections;

#if UNITY_ANDROID
	using System.Text;
	using System.Text.RegularExpressions;
	using System.IO;
#endif

#if UNITY_IPHONE
	using System.Runtime.InteropServices;
#endif


public class meminfo  {

	#if UNITY_ANDROID
		public struct meminf{
			//all numbers are in kiloBytes
			public int memtotal;
			public int memfree;
			public int active;
			public int inactive;
			public int cached;
			public int swapcached;
			public int swaptotal;
			public int swapfree;
		}
		
		public static meminf minf = new meminf();
		
		private static Regex re = new Regex(@"\d+");
		
		public static bool getMemInfo(){
			
			if(!File.Exists("/proc/meminfo")) return false;
			
		
			FileStream fs = new FileStream("/proc/meminfo", FileMode.Open, FileAccess.Read, FileShare.Read);
			StreamReader sr = new StreamReader(fs);
			
			string line;
			while((line = sr.ReadLine())!=null){
				line = line.ToLower().Replace(" ","");
				if(line.Contains("memtotal")){ minf.memtotal = mVal(line); }
				if(line.Contains("memfree")){ minf.memfree = mVal(line); }
				if(line.Contains("active")){ minf.active = mVal(line); }
				if(line.Contains("inactive")){ minf.inactive = mVal(line); }
				if(line.Contains("cached") && !line.Contains("swapcached")){ minf.cached = mVal(line); }
				if(line.Contains("swapcached")){ minf.swapcached = mVal(line); }
				if(line.Contains("swaptotal")){ minf.swaptotal = mVal(line); }
				if(line.Contains("swapfree")){ minf.swapfree = mVal(line); }
			}
			
			sr.Close(); fs.Close(); fs.Dispose();
			return true;
		}
		
		private static int mVal(string s){
			Match m = re.Match(s); return int.Parse(m.Value);
		}
	

	#endif
	
	#if UNITY_IPHONE
	
		public struct meminf{
			//all numbers are in bytes
			public int memtotal;
			public int memfree;
			public int memused;
		}
	
		public static meminf minf = new meminf();
		
		[DllImport("__Internal")]
		private static extern int igetRam(bool what);
	
	
	
		public static bool getMemInfo(){
		
			int rt;

			rt = minf.memfree = igetRam(true);//free
			rt = minf.memused = igetRam(false);//used
			if(rt==-1) return false;
			
			minf.memtotal = minf.memfree + minf.memused;
			
			return true;
			
		}
	
	#endif

}

