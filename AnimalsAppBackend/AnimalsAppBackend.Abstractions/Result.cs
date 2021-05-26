using System.Collections.Generic;

namespace AnimalsAppBackend.Abstractions
{
    public class Result<T> where T: class
    {
        public T Value { get; }

        public List<string> Errors { get; } = new List<string>();

        public bool Valid => Errors.Count == 0;

        private Result(T value)
        {
            Value = value;
        }

        private Result(string error)
        {
            Errors.Add(error);
        }

        public static Result<T> Create(T input)
        {
            return new Result<T>(input);
        }

        public static Result<T> CreateErrorResult(string error)
        {
            return new Result<T>(error);
        }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}
