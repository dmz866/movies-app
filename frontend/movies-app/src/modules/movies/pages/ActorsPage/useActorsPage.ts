import { useCallback, useContext, useEffect, useState } from "react";
import { getActorsByNameUseCase } from "../../api/use-cases";
import { ActorContext } from "../../context/ActorContext/ActorContext";
import { Actor } from "../../models";

export const useActorsPage = () => {
    const [isLoading, setIsLoading] = useState(false);
    const [actors, setActors] = useState<Actor[]>([]);
    const [noActorFound, setNoActorFound] = useState<boolean>(false);
    const { searchActorName, updateSearchActorName, actorsFound, updateActorsFound } = useContext(ActorContext);
    const [searchValue, setSearchValue] = useState('');

    const handleInput = (e: any) => {
        const fieldValue = e.nativeEvent.target.value;
        updateSearchActorName(fieldValue);
    }
    const handleSearch = useCallback(async (searchValue?: string) => {
        if (!searchValue) return;

        let result: Actor[] = [];

        setIsLoading(true);

        if (searchValue) {
            result = await getActorsByNameUseCase(searchValue);
        }

        setActors(result);

        updateActorsFound(result);
        setNoActorFound(result?.length === 0);
        setIsLoading(false);
    }, [setIsLoading, setActors, setNoActorFound, updateActorsFound]);


    useEffect(() => {
        if (!searchActorName) return;

        setSearchValue(searchActorName);
    }, [searchActorName]);

    useEffect(() => {
        if (!actorsFound) return;

        setActors(actorsFound);
    }, [actorsFound]);

    return {
        searchActorName,
        isLoading,
        actors,
        noActorFound,
        searchValue,
        handleInput,
        handleSearch,
        setActors,
    };
}