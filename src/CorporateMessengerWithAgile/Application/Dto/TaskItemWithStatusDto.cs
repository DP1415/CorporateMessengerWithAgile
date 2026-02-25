using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Dto;

public class TaskItemWithStatusDto : TaskItemSummaryDto
{
    public TaskItemStatus TaskStatus { get; set; }
}
