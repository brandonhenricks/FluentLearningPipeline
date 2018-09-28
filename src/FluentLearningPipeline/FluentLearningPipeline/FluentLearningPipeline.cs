using FluentLearningPipeline.Interfaces;
using Microsoft.ML;
using System;

namespace FluentLearningPipeline
{
    public class FluentLearningPipeline<TInput, TOutput> : IFluentLearningPipeline<TInput, TOutput> where TInput : class where TOutput : class, new()
    {
        private LearningPipeline _pipeline;

        private bool HasPipeline { get { return !(_pipeline is null); } }

        public LearningPipeline Pipeline { get; }

        public FluentLearningPipeline()
        {
        }

        public IFluentLearningPipeline<TInput, TOutput> Add(ILearningPipelineItem item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (HasPipeline)
            {
                _pipeline.Add(item);
            }

            return this;
        }

        public IFluentLearningPipeline<TInput, TOutput> BeginPipeline()
        {
            if (HasPipeline)
            {
                Clear();
                _pipeline = null;
            }

            _pipeline = new LearningPipeline();

            return this;
        }

        public IFluentLearningPipeline<TInput, TOutput> BeginPipeline(LearningPipeline pipeline)
        {
            if (pipeline is null) throw new ArgumentNullException(nameof(pipeline));

            if (HasPipeline)
            {
                Clear();
                _pipeline = null;
            }

            _pipeline = pipeline;

            return this;
        }

        public IFluentLearningPipeline<TInput, TOutput> Clear()
        {
            if (HasPipeline)
            {
                _pipeline.Clear();
            }

            return this;
        }

        public IFluentLearningPipeline<TInput, TOutput> Remove(ILearningPipelineItem item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (HasPipeline)
            {
                _pipeline.Remove(item);
            }

            return this;
        }

        public PredictionModel<TInput, TOutput> Train()
        {
            return _pipeline?.Train<TInput, TOutput>();
        }
    }
}
