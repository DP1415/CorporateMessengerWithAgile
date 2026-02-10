using Application.Dto.Summary;

namespace Application.Dto;

public class TaskItemWithStatusDto : TaskItemSummaryDto
{
    public int TaskStatus { get; set; }
}
