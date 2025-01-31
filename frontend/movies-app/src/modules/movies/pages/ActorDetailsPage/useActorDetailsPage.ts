import { useCallback, useState } from "react";
import { useNavigate } from "react-router";
import { getActorUseCase } from "../../api/use-cases/get-actor-use-case";
import { ACTORS_PATH } from "../../constants";
import { Actor } from "../../models";

export const useActorDetailsPage = () => {
    const [isLoading, setIsLoading] = useState(false);
    const [isFinished, setIsFinished] = useState(false);
    const [actor, setActor] = useState<Actor>();
    const navigate = useNavigate();

    const getActor = useCallback(async (actorId: number) => {
        let result: Actor | undefined;

        setIsLoading(true);

        if (!actorId) navigate(ACTORS_PATH);

        result = await getActorUseCase(actorId);
        setIsFinished(true);
        setActor(result);
        setIsLoading(false);
    }, [setIsLoading, setActor, navigate, setIsFinished]);

    return {
        isLoading,
        actor,
        isFinished,
        getActor,
    };
}