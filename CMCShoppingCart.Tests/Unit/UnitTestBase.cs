using System.Reflection;

namespace CMCShoppingCart.Tests.Unit
{
    public abstract class UnitTestBase<TSubject>
    {
        private readonly IDictionary<Type, object> _mocks = new Dictionary<Type, object>();

        public UnitTestBase()
        {
            var subjectType = typeof(TSubject);
            var argInstances = new List<object>();

            // create mock of constructor args
            var ctor = subjectType.GetConstructors().SingleOrDefault();
            if (ctor != null)
            {
                var args = ctor.GetParameters();
                foreach (var arg in args)
                {
                    var mock = Substitute.For(new[] { arg.ParameterType }, Array.Empty<object>());
                    _mocks.Add(arg.ParameterType, mock);
                    argInstances.Add(mock);
                }
            }

            // instantiate subject
            var subject = (TSubject?)Activator.CreateInstance(subjectType, argInstances.ToArray());
            if (subject == null)
                throw new Exception($"Cannot activate subject of type {subjectType}");
            Subject = subject;
        }

        protected TMock GetMock<TMock>()
            => (TMock)_mocks[typeof(TMock)];

        protected TSubject Subject { get; }
    }
}
