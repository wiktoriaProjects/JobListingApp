using Blazored.LocalStorage;
using JobListingApp.BlazorClient.ViewModels;

namespace JobListingApp.BlazorClient.Services
{
    public interface ILikesService
    {
        Task Add(LikedListing likedListing);
        Task Remove(LikedListing likedListing);
        Task<List<LikedListing>> GetSaved();
    }

    public class LikesService : ILikesService
    {
        private readonly ILocalStorageService _localStorageService;

        public LikesService(ILocalStorageService localStorageService)
        {
            this._localStorageService = localStorageService;
        }
        public async Task Add(LikedListing likedListing)
        {
            bool alreadyExists = false;
            var liked = await _localStorageService.GetItemAsync<List<LikedListing>>("JobBoardLiked");
            if (liked == null)
            {
                liked = new List<LikedListing>();
            }
            foreach (var item in liked)
            {
                if (item.Listing.Id == likedListing.Listing.Id)
                {
                    alreadyExists = true;
                    
                }
            }

            if (!alreadyExists)
            {
                liked.Add(likedListing);
            }
            await _localStorageService.SetItemAsync("JobBoardLiked", liked);


        }
        public async Task Remove(LikedListing ll)
        {
            LikedListing toRemove = null;
            var saved = await _localStorageService.GetItemAsync<List<LikedListing>>("JobBoardListing");
            if (saved == null)
                return;
            foreach(var item in saved)
            {
                if(item.Listing.Id == ll.Listing.Id)
                {
                    saved.Remove(item);
                }
            }
            await _localStorageService.SetItemAsync("JobBoardLiked", saved);

        }
        public async Task<List<LikedListing>> GetSaved()
        {
            // read or create new cart
            var cart = await _localStorageService.GetItemAsync<List<LikedListing>>("JobBoardLiked");
            if (cart == null)
            {
                cart = new List<LikedListing>();
            }
            return cart;
        }
    }
}
