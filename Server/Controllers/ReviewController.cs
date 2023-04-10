using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    /// <summary>
    /// Get a Review by Id
    /// </summary>
    /// <param name="reviewId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("id/{reviewId}")]
    public ActionResult<ReviewViewModel> GetReviewById(int reviewId)
    {
        try
        {
            ReviewViewModel result = _reviewService.GetReviewById(reviewId);
            return Ok(result);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get reviews of a smartphone
    /// </summary>
    /// <param name="smartphoneId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("smartphone/{smartphoneId}")]
    public ActionResult<List<ReviewViewModel>> GetReviewsFromSmartphoneId(int smartphoneId)
    {
        try
        {
            List<ReviewViewModel> result = _reviewService.GetReviewsForSmartphone(smartphoneId);
            return Ok(result);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get reviews made by a certain user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("user/{userId}")]
    public ActionResult<List<ReviewViewModel>> GetReviewsForUser(string userId)
    {
        try
        {
            List<ReviewViewModel> result = _reviewService.GetReviewsForUser(userId);
            return Ok(result);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get all reviews
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("all")]
    public ActionResult<List<ReviewViewModel>> GetAllReviews()
    {
        try
        {
            var result = _reviewService.GetAllReviews();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Create a review
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> CreateCategory(ReviewCreationRequest request)
    {
        try
        {
            await _reviewService.CreateReview(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update a review
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("update")]
    public async Task<ActionResult> UpdateReview(ReviewUpdateRequest request)
    {
        try
        {
            await _reviewService.UpdateReview(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a review by Id
    /// </summary>
    /// <param name="reviewId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{reviewId}")]
    public async Task<ActionResult> DeleteReview(int reviewId)
    {
        try
        {
            await _reviewService.DeleteReview(reviewId);
            return Ok();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
