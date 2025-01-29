import { useCallback, useState } from "react";
import { getActorsByNameUseCase } from "../../api/use-cases";
import { Actor } from "../../models";

export const useActorsPage = () => {
    const [isLoading, setIsLoading] = useState(false);
    const [actors, setActors] = useState<Actor[]>([]);
    const [noActorFound, setNoActorFound] = useState<boolean>(false);

    const handleSearch = useCallback(async (searchValue: string) => {
        let result: Actor[] = [];

        setIsLoading(true);

        if (searchValue) {
            result = await getActorsByNameUseCase(searchValue);
        }

        setActors(result);
        setNoActorFound(result?.length === 0);
        setIsLoading(false);
    }, [setIsLoading, setActors, setNoActorFound]);


    return {
        isLoading,
        actors,
        noActorFound,
        handleSearch,
    };
}