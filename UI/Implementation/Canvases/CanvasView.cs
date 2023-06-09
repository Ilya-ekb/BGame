﻿using Core.ObjectsSystem;

namespace Game.UI
{
    public class CanvasView : UiElementView<CanvasSetting, CanvasComponent>
    {
        public CanvasView(CanvasSetting setting, UiContext context, IDroppable parent) : base(setting, context, parent)
        {
        }
    }
}