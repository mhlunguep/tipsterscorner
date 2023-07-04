namespace TipstersCorner
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            //All the api end points here
            app.MapGet("/all-meeting-data", GetRaceMeetingData);
            app.MapGet("/meeting-data/{id}", GetSingleRaceMeetingData);
        }

        private static async Task<IResult> GetRaceMeetingData(IRaceMeetingData data)
        {
            try
            {
                return Results.Ok(await data.GetRaceMeetings());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetSingleRaceMeetingData(int id, IRaceMeetingData data)
        {
            try
            {
                var results = await data.GetRaceMetting(id);
                if (results == null) return Results.NotFound();

                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
