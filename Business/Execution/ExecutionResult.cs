using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Execution
{
    public class ExecutionResult
    {
        public IEnumerable<PrimaryDto> Data { get; set; }
        public List<string> Message { get; set; } = new List<string>();
        public List<string> Error { get; set; } = new List<string>();

        public bool IsSuccessful => !Error.Any();
    }
}
