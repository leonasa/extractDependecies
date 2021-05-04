using System;

namespace ExtractDependencies
{
    internal class Dependency : IEquatable<Dependency>
    {
        public string Name { get; set; }
        public string Version { get; set; }

        public bool Equals(Dependency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Version == other.Version;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Version);
        }

        public static bool operator ==(Dependency left, Dependency right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Dependency left, Dependency right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Version: {Version}";
        }
    }
}