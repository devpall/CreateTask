﻿using System;
using System.Collections.Generic;
using CreateTask.Logic;
using Xunit;

namespace CreateTask.Console.UnitTests.Logic
{
  public class OptionParserUnitTests
  {
    #region Nested type: CategoriesTests

    public class CategoriesTests
    {
      [Fact]
      public void P_flag_Should_Set_Personal_CategoryLabel() {
        var op = new OptionsParser(new List<string> {"-p"});
        Assert.True(op.Tags.Contains("Personal"));
      }

      [Fact]
      public void W_flag_Should_Set_Business_CategoryLabel() {
        var op = new OptionsParser(new List<string> {"-w"});
        Assert.True(op.Tags.Contains("Business"));
      }

      [Fact]
      public void B_flag_Should_Set_Business_CategoryLabel() {
        var op = new OptionsParser(new List<string> {"-b"});
        Assert.True(op.Tags.Contains("Business"));
      }

      [Fact]
      public void T_flag_Should_Set_Travel_CategoryLabel() {
        var op = new OptionsParser(new List<string> {"-t"});
        Assert.True(op.Tags.Contains("Travel"));
      }

      [Fact]
      public void I_flag_Should_Set_Info_CategoryLabel() {
        var op = new OptionsParser(new List<string> {"-i"});
        Assert.True(op.Tags.Contains("Info"));
      }

      [Fact]
      public void F_flag_Should_Set_Family_CategoryLabel() {
        var op = new OptionsParser(new List<string> {"-f"});
        Assert.True(op.Tags.Contains("Family"));
      }

      [Fact]
      public void H_flag_Should_Set_House_CategoryLabel() {
        var op = new OptionsParser(new List<string> {"-h"});
        Assert.True(op.Tags.Contains("Hus"));
      }

      [Fact]
      public void Multiple_flags_Should_Set_ManyCategoryLabels() {
        var op = new OptionsParser(new List<string> {"-h", "-t", "-b"});
        Assert.True(op.Tags.Contains("Hus"));
        Assert.True(op.Tags.Contains("Business"));
        Assert.True(op.Tags.Contains("Travel"));
      }
    }

    #endregion

    #region Nested type: DateTests

    public class DateTests
    {
      [Fact]
      public void TodayFlag_ShouldReturn_TodaysDate() {
        var optionsParser = new OptionsParser(new List<string> {"-td"});
        Assert.Equal(DateTime.Today, optionsParser.DueDate);
      }

      [Fact]
      public void TmFlag_shouldRetrun_TomorrowsDate() {
        var optionsParser = new OptionsParser(new List<string> {"-tm"});
        Assert.Equal(DateTime.Today.AddDays(1), optionsParser.DueDate);
      }

      [Fact]
      public void TwFlag_ShoudReturn_LastDayOfWeek_SE() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-tw"}, dateOfExecuting);

        DateTime expectedLastDayOfWeek = DateTime.Parse("2012-11-18");

        Assert.Equal(expectedLastDayOfWeek, optionsParser.DueDate);
      }

      [Fact]
      public void NwFlag_ShoudReturn_LastDayOfNextWeek_SE() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-nw"}, dateOfExecuting);
        DateTime expectedLastDayOfWeek = DateTime.Parse("2012-11-25");

        Assert.Equal(expectedLastDayOfWeek, optionsParser.DueDate);
      }

      [Fact]
      public void OnewFlag_ShoudReturn_LastDayOfNextWeek_SE() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-1w"}, dateOfExecuting);
        DateTime expectedLastDayOfWeek = DateTime.Parse("2012-11-23");

        Assert.Equal(expectedLastDayOfWeek, optionsParser.DueDate);
      }

      [Fact]
      public void MoFlag_ShouldReturn_ComingMonday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-mo"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-19"), optionsParser.DueDate);
      }


      [Fact]
      public void MFlag_ShouldReturn_ComingMonday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-m"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-19"), optionsParser.DueDate);
      }


      [Fact]
      public void TuFlag_ShouldReturn_ComingMonday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-tu"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-20"), optionsParser.DueDate);
      }


      [Fact]
      public void TiFlag_ShouldReturn_ComingMonday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-tu"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-20"), optionsParser.DueDate);
      }


      [Fact]
      public void WeFlag_ShouldReturn_ComingMonday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-we"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-21"), optionsParser.DueDate);
      }

      [Fact]
      public void OnFlag_ShouldReturn_ComingWdnesday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-on"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-21"), optionsParser.DueDate);
      }


      [Fact]
      public void ToFlag_ShouldReturn_ComingThursday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-to"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-22"), optionsParser.DueDate);
      }

      [Fact]
      public void ThFlag_ShouldReturn_ComingThursday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-th"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-22"), optionsParser.DueDate);
      }


      [Fact]
      public void FrFlag_ShouldReturn_ComingFriday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-fr"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-23"), optionsParser.DueDate);
      }

      [Fact]
      public void SaFlag_ShouldReturn_ComingMSaturday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-sa"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-17"), optionsParser.DueDate);
      }


      [Fact]
      public void LöFlag_ShouldReturn_ComingSaturday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-lö"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-17"), optionsParser.DueDate);
      }

      [Fact]
      public void SuFlag_ShouldReturn_ComingMSunday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-su"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-18"), optionsParser.DueDate);
      }

      [Fact]
      public void SöFlag_ShouldReturn_ComingMSunday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-sö"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-11-18"), optionsParser.DueDate);
      }


      [Fact]
      public void Jan_InBeginning_Should_Return_FirstDayInJanuary() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-jan"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-01-01"), optionsParser.DueDate);
      }

      [Fact]
      public void Feb_InBeginning_Should_Return_FirstDayInFebruary() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-feb"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-02-01"), optionsParser.DueDate);
      }

      [Fact]
      public void Mar_InBeginning_Should_Return_FirstDayInMars() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-mar"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-03-01"), optionsParser.DueDate);
      }

      [Fact]
      public void Apr_InBeginning_Should_Return_FirstDayInApril() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-apr"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-04-01"), optionsParser.DueDate);
      }

      [Fact]
      public void May_InBeginning_Should_Return_FirstDayInMay() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-may"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-05-01"), optionsParser.DueDate);
      }


      [Fact]
      public void Maj_InSwedish_InBeginning_Should_Return_FirstDayInMay() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-maj"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-05-01"), optionsParser.DueDate);
      }

      [Fact]
      public void Jun_InBeginning_Should_Return_FirstDayInJune() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-jun"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-06-01"), optionsParser.DueDate);
      }

      [Fact]
      public void Jul_InBeginning_Should_Return_FirstDayInJuly() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-jul"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-07-01"), optionsParser.DueDate);
      }


      [Fact]
      public void Aug_InBeginning_Should_Return_FirstDayInAugust() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-aug"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-08-01"), optionsParser.DueDate);
      }


      [Fact]
      public void Sep_InBeginning_Should_Return_FirstDayInSeptember() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-sep"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-09-01"), optionsParser.DueDate);
      }


      [Fact]
      public void Oct_InBeginning_Should_Return_FirstDayInOctober() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-oct"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-10-01"), optionsParser.DueDate);
      }

      [Fact]
      public void Okt_InBeginning_Should_Return_FirstDayInOctober() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-okt"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-10-01"), optionsParser.DueDate);
      }

      [Fact]
      public void Nov_InBeginning_Should_Return_FirstDayInNovember() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-nov"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2013-11-01"), optionsParser.DueDate);
      }


      [Fact]
      public void Dec_InBeginning_Should_Return_FirstDayInOctober() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        var optionsParser = new OptionsParser(new List<string> {"-dec"}, dateOfExecuting);

        Assert.Equal(DateTime.Parse("2012-12-01"), optionsParser.DueDate);
      }

      [Fact]
      public void SwedishStyleDate20121015_ShouldParseToOctober15th2012() {
        var op = new OptionsParser(new List<string> {"-d2012-10-15"});
        Assert.Equal(DateTime.Parse("2012-10-15"), op.DueDate);
      }

      [Fact]
      public void UsStyleDate151012_ShouldParseToOctober15th2012() {
        var op = new OptionsParser(new List<string> {"-d10/15/2012"});
        Assert.Equal(DateTime.Parse("2012-10-15"), op.DueDate);
      }
    }

    #endregion

    #region Nested type: ImportanceTests

    public class ImportanceTests
    {
      [Fact]
      public void Importance_Hp_ShouldBeParsedAsHighImportance() {
        var op = new OptionsParser(new List<string> {"-hp"});
        Assert.Equal(TaskPriority.High, op.Importance);
      }

      [Fact]
      public void Importance_Lp_ShouldBeParsedAsLowImportance() {
        var op = new OptionsParser(new List<string> {"-lp"});
        Assert.Equal(TaskPriority.Low, op.Importance);
      }

      [Fact]
      public void Importance_Nothing_ShouldBeParsedAsNormalImportance() {
        var op = new OptionsParser(new List<string> {""});
        Assert.Equal(TaskPriority.Normal, op.Importance);
      }
    }

    #endregion

    
  }
}