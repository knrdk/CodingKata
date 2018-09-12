using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;

namespace TransitiveDependencies
{
    public class DependenciesAnalyzer
    {
        private Dictionary<string, System.Collections.Generic.HashSet<string>> _dependencies =
            new Dictionary<string, System.Collections.Generic.HashSet<string>>();

        public void AddModule(string moduleName, IEnumerable<string> dependencies = null)
        {
            IEnumerable<string> existingDependencies = _dependencies.ContainsKey(moduleName) ?
                _dependencies[moduleName] : null;
            var dependenciesSet = CreateHashSet(existingDependencies, dependencies);
            _dependencies[moduleName] = dependenciesSet;
        }

        public Option<IEnumerable<string>> GetDependencies(string moduleName)
        {
            if (_dependencies.ContainsKey(moduleName))
            {
                return Option<IEnumerable<string>>.Some(GetDependenciesInternal(moduleName));
            }
            return Option<IEnumerable<string>>.None;
        }

        private IEnumerable<string> GetDependenciesInternal(string moduleName)
        {
            var resolvedDependencies = new System.Collections.Generic.HashSet<string>();
            var dependenciesToResolve = new Queue<string>();
            EnqueueMany(dependenciesToResolve, _dependencies[moduleName]);

            while (dependenciesToResolve.Any())
            {
                var dependency = dependenciesToResolve.Dequeue();
                if (dependency == moduleName || resolvedDependencies.Contains(dependency))
                {
                    continue;
                }

                IEnumerable<string> transitiveDependencies = _dependencies[dependency];
                EnqueueMany(dependenciesToResolve, transitiveDependencies);

                resolvedDependencies.Add(dependency);
            }

            return resolvedDependencies;
        }

        private void EnqueueMany<T>(Queue<T> queue, IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                queue.Enqueue(item);
            }
        }

        private System.Collections.Generic.HashSet<T> CreateHashSet<T>(IEnumerable<T> source1, IEnumerable<T> source2){
            source1 = source1 ?? Enumerable.Empty<T>();
            source2 = source2 ?? Enumerable.Empty<T>();

            IEnumerable<T> allItems = source1.Concat(source2);

            return new System.Collections.Generic.HashSet<T>(allItems);
        }
    }
}