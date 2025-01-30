import { useCallback, useMemo, useState } from "react";
import { Actor } from "../../models";
import { IActorContext } from "./ActorContext";

export const useActorContext = () => {
    const [searchActorName, setSearchActorName] = useState<string | undefined>();
    const [actorsFound, setActorsFound] = useState<Actor[]>();
    const updateSearchActorName = useCallback((value: string) => {
        setSearchActorName(value);
    }, []);
    const updateActorsFound = useCallback((value: Actor[]) => {
        setActorsFound(value);
    }, []);
    const contextValue = useMemo(() => ({
        searchActorName,
        actorsFound,
        updateSearchActorName,
        updateActorsFound,
    } as IActorContext), [searchActorName, actorsFound, updateSearchActorName, updateActorsFound]);

    return {
        contextValue,
    };
}