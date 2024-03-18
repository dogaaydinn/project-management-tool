using Core.Extensions;
using Newtonsoft.Json;

namespace Core.Services.Result;

public class ServiceCollectionResult<T> : ServiceResult
{
    [JsonProperty] public bool HasData { get; private set; }

    [JsonProperty] public IList<T>? Data { get; private set; }

    [JsonProperty] public int TotalItemCount { get; private set; }

    [JsonProperty] public int TotalPageCount { get; private set; }

    [JsonProperty] public int CurrentPage { get; private set; }

    [JsonProperty] public int? NextPage { get; private set; }

    # region Set Data Overloads

    public void SetData(IEnumerable<T> data, int page = 1, int pageSize = int.MaxValue, string? successMessage = null)
    {
        var dataList = data.ToList();
        SetTotalItemCount(dataList.Count);
        SetTotalPageCount(dataList.Count, pageSize);
        SetCurrentPage(page, pageSize);
        SetData(dataList.Paginate(page, pageSize), successMessage);
    }

    private void SetData(IList<T>? data, string? successMessage = null)
    {
        if (data == null || data.Count == 0)
        {
            Warning(ServiceResultConstants.NoItemsFound);
        }
        else
        {
            HasData = true;
            Success(successMessage ?? ServiceResultConstants.Success);
        }

        DataType = typeof(T).Name;
        IsList = true;
        Data = data;
    }

    # endregion Set Data Overloads

    # region Helper Methods

    private void SetTotalPageCount(int dataListCount, int pageSize)
    {
        TotalPageCount = (int)Math.Ceiling((double)dataListCount / pageSize);
    }

    private void SetTotalItemCount(int? totalItemCount)
    {
        TotalItemCount = totalItemCount.GetValueOrDefault(0);
    }

    private void SetCurrentPage(int currentPage = 1, int pageSize = int.MaxValue)
    {
        CurrentPage = currentPage;

        if (pageSize < int.MaxValue && TotalItemCount > pageSize && CurrentPage < TotalPageCount)
            SetNextPage();
        else
            ClearNextPage();
    }

    private void SetNextPage()
    {
        NextPage = CurrentPage + 1;
    }

    private void ClearNextPage()
    {
        NextPage = null;
    }

    # endregion Helper Methods

    # region Fail Overloads

    public override void Fail()
    {
        base.Fail();
        Data = null;
        HasData = false;
    }

    public override void Fail(string code, string description)
    {
        base.Fail(code, description);
        Data = null;
        HasData = false;
    }

    public override void Fail(string description)
    {
        base.Fail(description);
        Data = null;
        HasData = false;
    }

    public override void Fail(ServiceResult? result)
    {
        base.Fail(result);
        Data = null;
        HasData = false;
    }

    public override void Fail(Exception ex)
    {
        base.Fail(ex);
        Data = null;
        HasData = false;
    }

    # endregion Fail Overloads
}