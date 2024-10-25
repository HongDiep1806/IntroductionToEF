namespace IntroductionToEF.Model
{
    public class RequestLogInfo
    {
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string Path { get; set; }
        public string Host { get; set; }
        public string Headers { get; set; }
        public string Body { get; set; }

        public string toString()
        {
            return $"Request Information : /n" +
                    $"Method: {this.Method}/n" +
                    $"Protocol : {this.Protocol}/n" +
                    $"Path : {this.Path}/n" +
                    $"Host : {this.Host}/n" +
                    $"Headers: {this.Headers}/n" +
                    $"Body Request : {this.Body}";
        }


    }

    

}
