using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ExampleTest_Tutorial_13.Models;
using ExampleTest_Tutorial_13.Models.Requests;

namespace ExampleTest_Tutorial_13.Util
{
    public class ValidationHelper
    {
        private const string DATE_REGEX = @"^([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])$)";

        public static List<Error> ValidateNewOrderRequest(NewOrderRequest request)
        {
            List<Error> errors = new List<Error>();
            if (!IsDateValid(request.DateAccepted))
            {
                errors.Add(new Error("DateAccepted", request.DateAccepted,
                    "Date doesnt match regex ^([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01])$)"));
            }

            if (request.Confectionery.Count == 0)
            {
                errors.Add(new Error("Confectioneries", request.Confectionery.ToString(), "List should not be null or empty"));
            }
            if (string.IsNullOrEmpty(request.Notes))
            {
                errors.Add(new Error("Notes", request.Notes, "Notes should not be null or empty"));
            }
            return errors;
        }

        private static bool IsDateValid(string requestDateAccepted)
        {
            return Regex.IsMatch(requestDateAccepted, DATE_REGEX);
        }
    }
}