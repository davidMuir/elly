namespace Elly
{
    public abstract class Component<TProps> : Component
    {
        protected TProps Props { get; set; }

        public virtual void Init(
            TProps props,
            params Element[] children)
        {
            Props = props;
            Children = children;
        }
    }

    public abstract class Component
    {
        protected Element[] Children { get; set; }

        public virtual void Init(Element[] children)
        {
            Children = children;
        }

        public abstract Element Render();
    }
}