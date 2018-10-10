using Microsoft.ML.Legacy;

namespace FluentLearningPipeline.Interfaces
{
    public interface IFluentLearningPipeline<TInput, TOutput> where TInput : class where TOutput : class, new()
    {
        LearningPipeline Pipeline { get; }
        IFluentLearningPipeline<TInput, TOutput> BeginPipeline();
        IFluentLearningPipeline<TInput, TOutput> Add(ILearningPipelineItem item);
        IFluentLearningPipeline<TInput, TOutput> Clear();
        IFluentLearningPipeline<TInput, TOutput> Remove(ILearningPipelineItem item);
        PredictionModel<TInput, TOutput> Train();
    }
}
