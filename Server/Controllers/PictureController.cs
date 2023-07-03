using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Shared.Responses;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PictureController : ControllerBase
{
    private readonly IPictureService _pictureService;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public PictureController(
        IPictureService pictureService,
        IWebHostEnvironment hostingEnvironment)
    {
        _pictureService = pictureService;
        _hostingEnvironment = hostingEnvironment;
    }

    /// <summary>
    /// Get a picture by Id
    /// </summary>
    /// <param name="pictureId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{pictureId}")]
    public ActionResult<PictureViewModel> GetPictureById(int pictureId)
    {
        try
        {
            var result = _pictureService.GetPictureById(pictureId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Get a picture by Id
    /// </summary>
    /// <param name="smartphoneId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("phone/{smartphoneId}")]
    public ActionResult<List<PictureViewModel>> GetPicturesForSmartphone(int smartphoneId)
    {
        try
        {
            var result = _pictureService.GetPicturesForSmartphone(smartphoneId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Get all pictures (alls coz issue with using just "all")
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("alls")]
    public ActionResult<List<PictureViewModel>> GetAllPictures()
    {
        try
        {
            var result = _pictureService.GetAllPictures();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Upload/Add a picture
    /// </summary>
    /// <param name="files"></param>
    /// <param name="smartphoneId"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("upload/{smartphoneId}")]
    public async Task<ActionResult<IList<FileUploadResponse>>> PostFile(
       [FromForm] IEnumerable<IFormFile> files, int smartphoneId)
    {
        var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");

        var uploadResults = await _pictureService.AddPicture(files, smartphoneId);

        return new CreatedResult(resourcePath, uploadResults);
    }

    /// <summary>
    /// Update a picture
    /// </summary>
    /// <param name="files"></param>
    /// <param name="smartphoneId"></param>
    /// <param name="pictureId"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("upload/{smartphoneId}/{pictureId}")]
    public async Task<ActionResult<IList<FileUploadResponse>>> UpdateFile([FromForm] IEnumerable<IFormFile> files, int smartphoneId, int pictureId)
    {
        var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");

        var uploadResults = await _pictureService.UpdatePicture(files, smartphoneId, pictureId);

        return new CreatedResult(resourcePath, uploadResults);
    }

    /// <summary>
    /// Delete a picture by Id
    /// </summary>
    /// <param name="pictureId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("delete/{pictureId}")]
    public async Task<ActionResult> DeleteCategory(int pictureId)
    {
        try
        {
            await _pictureService.DeletePicture(pictureId);
            return Ok();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
