using System;
using static RootServer.Shared._Editor.Pointer_Service;



namespace RootServer.Shared.Airtable._Core.Static
{
	public static class StaticPointers
	{
        public static SPointer PointerApp { get; set; } = new(null);
        public static SPointer PointerWorkspace { get; set; } = new(PointerApp);
        public static SPointer PointerTable { get; set; } = new(PointerWorkspace);
        public static SPointer PointerItem { get; set; } = new(PointerItem);

        public static List<SPointer> activePointers = new();


        public class SPointer
        {
            private SPointer? parentPointer;
            private Pointer? currentPointer;

            public Pointer? CurrentPointer
            {
                get { return currentPointer; }
                set {
                    currentPointer = value;
                    activePointers = new();
                    CreateActivePointers();
                }
            }



            public SPointer(SPointer? _parentPointer)
            {
                parentPointer = _parentPointer;
            }



            public void CreateActivePointers()
            {
                activePointers.Add(this);
                if (parentPointer != null)
                    parentPointer.CreateActivePointers();
            }
        }
    }
}