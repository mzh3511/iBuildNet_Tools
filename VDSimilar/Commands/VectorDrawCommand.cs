namespace VDSimilar.SimilarityLib
{
    public abstract class VectorDrawCommand
    {
        public abstract string CommandName { get; }

        public abstract object Execute(vdControls.vdFramedControl vdFramedControl);
    }
}