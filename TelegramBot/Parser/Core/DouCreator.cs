﻿namespace TelegramBot.Parser;

public class DouCreator : ParserCreator
{
    public override IParser CreateParser()
    {
        return new ParserDouUa();
    }

    public override ICompare Compare()
    {
        return new Compare();
    }
}