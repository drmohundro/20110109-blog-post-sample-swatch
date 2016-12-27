using System;

namespace Swatch
{
    public class Switcher<T>
    {
        public Decision Case(Predicate<T> condition, Action<T> branch)
        {
            return new Decision {Condition = condition, Branch = branch};
        }

        public Decision Default(Action<T> branch)
        {
            return new Decision {Condition = x => true, Branch = branch};
        }

        public void Switch(T instance, params Decision[] cases)
        {
            foreach (var @case in cases)
            {
                if (@case.Condition(instance))
                {
                    @case.Branch(instance);
                    break;
                }
            }
        }

        public class Decision
        {
            public Predicate<T> Condition { get; set; }
            public Action<T> Branch { get; set; }
        }
    }
}
