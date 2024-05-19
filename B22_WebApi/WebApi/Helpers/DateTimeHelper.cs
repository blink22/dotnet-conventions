namespace WebApi.Helpers

                                    // Helper vs Util Classes //

    // Helper classes typically contain methods that provide specific functionality or perform specific tasks 
    // related to a particular domain or context within an application. 
    // On the other hand, utility classes (util classes) often contain a collection of general-purpose methods 
    // that provide common functionality not necessarily tied to a specific domain or context.



{
    // Helper class for date and time related operations
    public static class DateTimeHelper
    {
        // Method to check if a string represents a valid DateTime
        public static bool BeAValidDateTime(string dateTime)
        {
            if (dateTime == null) { return true; } // If dateTime is null, consider it as valid
            if (DateTime.TryParse(dateTime, out DateTime parsedDate)) { return true; } // Try parsing the string to DateTime, if successful, return true
            else return false; // Otherwise, return false
        }

        // Method to check if a DateTime is not in the future
        public static bool NotInTheFuture(string? dateTime)
        {
            if (dateTime == null) { return true; } // If dateTime is null, consider it as not in the future
            try
            {
                DateTime parsedDate = DateTime.Parse(dateTime); // Parse the string to DateTime
                return parsedDate < DateTime.UtcNow; // Check if the parsed DateTime is before the current UTC time
            }
            catch (Exception)
            {
                return false; // If parsing fails, return false
            }
        }

        // Method to check if an integer represents a valid month (1 to 12)
        public static bool BeAValidMonth(int? month)
        {
            if (month != null && (month < 1 || month > 12))
            {
                return false; // If month is not null and not between 1 and 12, return false
            }
            return true; // Otherwise, return true
        }

        // Method to check if toDate is greater than fromDate
        public static bool BeGreaterThanFromDate(string fromDate, string toDate)
        {
            if (DateTime.TryParse(fromDate, out DateTime fromDateTime) &&
                DateTime.TryParse(toDate, out DateTime toDateTime))
            {
                return toDateTime > fromDateTime; // Return true if toDate is greater than fromDate
            }
            return false; // Otherwise, return false
        }
    }
}
