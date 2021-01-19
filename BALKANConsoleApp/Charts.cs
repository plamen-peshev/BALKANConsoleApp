using BALKAN;
using System;
using System.Collections.Generic;

namespace BALKANConsoleApp
{
    public static class Charts
    {
        public static void HelloOrgChart()
        {
            var chartService = new ChartService();
            var options = new OptionsCreateNewChart
            {
                ChartId = "HelloOrgChart",
                TemplateName = "Sofia"
            };

            var result = chartService.Create(options);

            if (result.IsSuccess)
            {
                Console.WriteLine("Hello OrgChart. Successfully created chart with id MyChartId and template Sofia!");
            }
            else
            {
                Console.WriteLine(result.Error);
                Console.WriteLine("Failed! Verify ApiAccessKey!");
            }
        }


        public static void AddEmployees()
        {
            var chartService = new ChartService();
            var options = new OptionsCreateNewChart
            {
                ChartId = "AddEmployees",
                TemplateName = "Sofia",
                Empty = true
            };
            var resultCreate = chartService.Create(options);

            if (!resultCreate.IsSuccess)
            {
                Console.WriteLine(resultCreate.Error);
            }

            var optionsAddNode = new OptionsAddNode
            {
                ChartId = "AddEmployees",
                Node = new Dictionary<string, string>
                {
                    { "id",  "1" },
                    { "Name",  "John Smith" }
                }
            };

            var resultAddNode = chartService.AddNode(optionsAddNode);

            if (!resultAddNode.IsSuccess)
            {
                Console.WriteLine(resultAddNode.Error);
            }


            optionsAddNode = new OptionsAddNode
            {
                ChartId = "AddEmployees",
                Node = new Dictionary<string, string>
                            {
                                { "id",  "2" },
                                { "pid",  "1" },
                                { "Name",  "Jack Daniels" }
                            }
            };

            resultAddNode = chartService.AddNode(optionsAddNode);

            if (!resultAddNode.IsSuccess)
            {
                Console.WriteLine(resultAddNode.Error);
            }

            optionsAddNode = new OptionsAddNode
            {
                ChartId = "AddEmployees",
                Node = new Dictionary<string, string>
                            {
                                { "id",  "3" },
                                { "pid",  "1" },
                                { "Name",  "Mickey Mouse" },
                                { "tags",  "blue,assistant" }
                            }
            };

            resultAddNode = chartService.AddNode(optionsAddNode);

            if (!resultAddNode.IsSuccess)
            {
                Console.WriteLine(resultAddNode.Error);
            }


            optionsAddNode = new OptionsAddNode
            {
                ChartId = "AddEmployees",
                Node = new Dictionary<string, string>
                            {
                                { "id",  "4" },
                                { "pid",  "1" },
                                { "Name",  "Ana Garson" },
                                { "Photo",  "https://cdn.balkan.app/shared/2.jpg" },
                                { "Country",  "USA" },
                                { "City",  "Las Vegas" },
                                { "JobTitle",  "IT Manager" },
                                { "Email",  "ana.garson@balkan.app" }
                            }
            };

            resultAddNode = chartService.AddNode(optionsAddNode);

            if (!resultAddNode.IsSuccess)
            {
                Console.WriteLine(resultAddNode.Error);
            }
        }


        public static void AddNodes()
        {
            var chartService = new ChartService();
            var resultAddNodes = chartService.AddNodes(new OptionsAddNodes
            {
                ChartId= "AddNodes",
                Nodes = new List<Dictionary<string, string>> 
                { 
                    new Dictionary<string, string> { { "id",  "1" }, { "Name",  "John Smith" } } ,
                    new Dictionary<string, string> { { "id",  "2" }, { "pid",  "1" }, { "Name",  "Jack Daniels" } },
                    new Dictionary<string, string> { { "id",  "3" }, { "pid",  "1" }, { "Name",  "Mickey Mouse" }, { "tags",  "blue,assistant" }},
                    new Dictionary<string, string> { { "id",  "4" }, { "pid",  "1" }, { "Name",  "Ana Garson" }, { "Photo",  "https://cdn.balkan.app/shared/2.jpg" },{ "Country",  "USA" },{ "City",  "Las Vegas" },{ "JobTitle",  "IT Manager" },{ "Email",  "ana.garson@balkan.app" }}
                }
            });

            if (!resultAddNodes.IsSuccess)
            {
                Console.WriteLine(resultAddNodes.Error);
            }
        }

        public static void UpdateNode()
        {
            CreateTestChart("UpdateNodeChart");
            var chartService = new ChartService();
            var resultUpdateNode  = chartService.UpdateNode(new OptionsUpdateNode 
            {
                ChartId = "UpdateNodeChart",
                Node = new Dictionary<string, string> 
                { 
                    { "id", "_sfWf" }, 
                    { "Name", "Alexandar Smith" }, 
                    { "JobTitle", "CEO" } 
                }
            });

            if (!resultUpdateNode.IsSuccess)
            {
                Console.WriteLine(resultUpdateNode.Error);
            }
        }

        public static void RemoveNode()
        {
            CreateTestChart("RemoveNodeChart");

            var chartService = new ChartService();
            var resultRemoveNode = chartService.RemoveNode(new OptionsRemoveNode
            {
                ChartId = "RemoveNodeChart",
                NodeId = "_s7Wf"
            });

            if (!resultRemoveNode.IsSuccess)
            {
                Console.WriteLine(resultRemoveNode.Error);
            }
        }


        public static void GetNode()
        {
            CreateTestChart("GetNodeChart");

            var chartService = new ChartService();
            var resultGetNode = chartService.GetNode(new OptionsGetNode
            {
                ChartId = "GetNodeChart",
                NodeId = "_s7Wf"
            });

            if (!resultGetNode.IsSuccess)
            {
                Console.WriteLine(resultGetNode.Error);
            }
        }

        public static void GetNodes()
        {
            CreateTestChart("GetNodesChart");


            var chartService = new ChartService();
            var resultGetNodes = chartService.GetNodes(new OptionsChart
            {
                ChartId = "GetNodesChart"
            });

            if (!resultGetNodes.IsSuccess)
            {
                Console.WriteLine(resultGetNodes.Error);
            }
        }


        public static void Search()
        {
            CreateTestChart("SearchChart");

            var chartService = new ChartService();
            var optionsSearch = new OptionsSearch
            {
                RetrieveFields = new List<string> { "Name", "JobTitle", "MyPropertyName" },
                Skip = 1,
                Take = 100,
                Search = "So Ed",
                SearchInFileds = new List<string> { "Name" }
            };

            var resultListAllNodes = chartService.Search(optionsSearch);

            if (!resultListAllNodes.IsSuccess)
            {
                Console.WriteLine(resultListAllNodes.Error);
            }
            else
            {
                foreach (var node in resultListAllNodes.Nodes)
                {
                    Console.WriteLine($"node.id = {node["id"]}");
                    Console.WriteLine($"node.__chartId = {node["__chartId"]}");
                    Console.WriteLine($"node.__searchField = {node["__searchField"]}");
                    Console.WriteLine($"node.__searchMarks = {node["__searchMarks"]}");
                    Console.WriteLine($"node.__score = {node["__score"]}");
                    if (node.ContainsKey("Name"))
                        Console.WriteLine($"node.Name = {node["Name"]}");
                    if (node.ContainsKey("JobTitle"))
                        Console.WriteLine($"node.JobTitle = {node["JobTitle"]}");
                    if (node.ContainsKey("MyPropertyName"))
                        Console.WriteLine($"node.MyPropertyName = {node["MyPropertyName"]}");
                }
            }
        }

        public static void CreateUpdateRemoveList()
        {
            var chartService = new ChartService();
            var optionsCreateNewChart = new OptionsCreateNewChart
            {
                ChartId = "CreateUpdateRemoveListChart",
                TemplateName = "Berlin"
            };
            var resultChart = chartService.Create(optionsCreateNewChart);

            if (!resultChart.IsSuccess)
            {
                Console.WriteLine(resultChart.Error);
            }

            var optionsUpdateChart = new OptionsUpdateChart
            {
                NewChartId = "CreateUpdateRemoveListChartNewUpdated",
                NewTemplateName = "London",
                OldChartId = "CreateUpdateRemoveListChart"
            };

            resultChart = chartService.Update(optionsUpdateChart);
            if (!resultChart.IsSuccess)
            {
                Console.WriteLine(resultChart.Error);
            }

            var optionsList = new OptionsList
            {
                Skip = 0,
                Take = 10,
                WildcardSearchPattern = "*NewUpdated*"
            };

            var resultList = chartService.ListDescriptors(optionsList);


            if (!resultList.IsSuccess)
            {
                Console.WriteLine(resultList.Error);
            }

            var optionsChart = new OptionsChart
            {
                ChartId = "CreateUpdateRemoveListChartNewUpdated"
            };

            var resultRemove = chartService.Remove(optionsChart);

            if (!resultRemove.IsSuccess)
            {
                Console.WriteLine(resultRemove.Error);
            }
        }

        public static void GenerateNodeIds()
        {
            CreateTestChart("GenerateNodeIdsChart");

            var chartService = new ChartService();

            var optionsGenerateNodeIds = new OptionsGenerateNodeIds
            {
                ChartId = "GenerateNodeIdsChart",
                Number = 10
            };

            var resultGenerateNodeIds = chartService.GenerateNodeIds(optionsGenerateNodeIds);

            if (!resultGenerateNodeIds.IsSuccess)
            {
                Console.WriteLine(resultGenerateNodeIds.Error);
            }
            else
            {
                foreach (var id in resultGenerateNodeIds.Ids)
                {
                    Console.WriteLine(id);
                }
            }
        }

        public static void CreateTestChart(string chartId)
        {
            var chartService = new ChartService();

            chartService.Create(new OptionsCreateNewChart
            {
                ChartId = chartId,
                TemplateName = "Berlin"
            });           
        }
    }
}
