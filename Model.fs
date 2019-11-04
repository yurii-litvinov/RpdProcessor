module RpdProcessor.Model

type Competence =
    {
        Name: string;
        Description: string
    }

type PlanCompetences =
    {
        Year: string;
        Competences: Competence seq
    }

type Model =
    {
        Plans: Map<string, PlanCompetences seq>
    }


