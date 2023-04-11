using Core.Chapters;

namespace Game.Contexts
{
    public class MainContext : BaseContext
    { 
        public Chapter CurrentChapter { get; private set; }

        public void SetChapter(Chapter chapter)
        {
            CurrentChapter = chapter;
        }
    }
}