using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Core.Entities;

public class Feature : CreatedCommon
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Descripsion { get; set; } = string.Empty;
}
