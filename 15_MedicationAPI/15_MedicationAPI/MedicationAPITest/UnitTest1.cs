using MedicationAPI.Controllers;
using MedicationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MedicationAPITest
{
    public class UnitTest1
    {
        private chdbContext context;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<chdbContext>().UseInMemoryDatabase(databaseName: "Medication_Tests").Options;
            context = new chdbContext(options);

            context.Medications.AddRange(
                new Medication
                {
                    MedicationId = 1,
                    MedicationDescription = "Pain Reliever",
                    MedicationCost = 1.0M
                },
                new Medication
                {
                    MedicationId = 2,
                    MedicationDescription = "Ibuprofen",
                    MedicationCost = 1.25M
                },
                new Medication
                {
                    MedicationId = 3,
                    MedicationDescription = "Advil",
                    MedicationCost = 1.5M
                }
            );

            context.SaveChanges();
        }

        [Fact]
        public async Task Get_NoInput_ReturnsMedications()
        {
            // Assert
            var medicationsController = new MedicationsController(context);

            // Act
            var actionResult = await medicationsController.GetMedications();

            // Arrange
            Assert.IsType<ActionResult<IEnumerable<Medication>>>(actionResult);
            var genericMedications = actionResult.Value;
            var medications = genericMedications as List<Medication>;
            Assert.Equal(3, medications.Count);
            Assert.Equal(1, medications[0].MedicationId);
            Assert.Equal("Ibuprofen", medications[1].MedicationDescription);
            Assert.Equal(1.5M, medications[2].MedicationCost);
        }
    }
}
