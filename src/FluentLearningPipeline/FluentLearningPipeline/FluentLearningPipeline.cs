using FluentLearningPipeline.Interfaces;
using Microsoft.ML;
using System;

namespace FluentLearningPipeline
{
    /// <summary>
    /// Wrapper class to use Fluent Syntax with <see cref="LearningPipeline"/>LearningPipeline</see>
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class FluentLearningPipeline<TInput, TOutput> : IFluentLearningPipeline<TInput, TOutput> where TInput : class where TOutput : class, new()
    {
        #region Private Fields
        private LearningPipeline _pipeline;

        private bool HasPipeline { get { return !(_pipeline is null); } }
        #endregion

        #region Public Properties
        public LearningPipeline Pipeline { get { return _pipeline; } }
        #endregion

        #region Public Constructor
        public FluentLearningPipeline()
        {
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Add a <see cref="ILearningPipelineItem"/>ILearningPipelineItem</see> to the LearningPipeline
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IFluentLearningPipeline<TInput, TOutput> Add(ILearningPipelineItem item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (HasPipeline)
            {
                _pipeline.Add(item);
            }

            return this;
        }

        /// <summary>
        /// Begin a <see cref="LearningPipeline"/>LearningPipeline</see>
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Begin a <see cref="LearningPipeline"/>LearningPipeline</see>
        /// </summary>
        /// <param name="pipeline"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Removes existing <see cref="ILearningPipelineItem"/>ILearningPipelineItem</see> items.
        /// </summary>
        /// <returns></returns>
        public IFluentLearningPipeline<TInput, TOutput> Clear()
        {
            if (HasPipeline)
            {
                _pipeline.Clear();
            }

            return this;
        }
        /// <summary>
        /// Removes an existing <see cref="ILearningPipelineItem"/>ILearningPipelineItem</see> item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IFluentLearningPipeline<TInput, TOutput> Remove(ILearningPipelineItem item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (HasPipeline)
            {
                _pipeline.Remove(item);
            }

            return this;
        }

        /// <summary>
        /// Train a <see cref="PredictionModel"/>PredictionModel</see>
        /// </summary>
        /// <returns></returns>
        public PredictionModel<TInput, TOutput> Train()
        {
            return _pipeline?.Train<TInput, TOutput>();
        }

        #endregion
    }
}
