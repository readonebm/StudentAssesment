using Microsoft.EntityFrameworkCore;

namespace StudentAssesment.Models
{
    public class PagInatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        
        public PagInatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PagInatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagInatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
