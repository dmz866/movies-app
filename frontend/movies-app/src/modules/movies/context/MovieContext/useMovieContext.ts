import { useCallback, useMemo, useState } from "react";
import { Movie } from "../../models";
import { IMovieContext } from "./MovieContext";

export const useMovieContext = () => {
    const [searchMovieName, setSearchMovieName] = useState<string | undefined>();
    const [moviesFound, setMoviesFound] = useState<Movie[]>();
    const updateSearchMovieName = useCallback((value: string) => {
        setSearchMovieName(value);
    }, []);
    const updateMoviesFound = useCallback((value: Movie[]) => {
        setMoviesFound(value);
    }, []);
    const contextValue = useMemo(() => ({
        searchMovieName,
        moviesFound,
        updateSearchMovieName,
        updateMoviesFound,
    } as IMovieContext), [searchMovieName, moviesFound, updateSearchMovieName, updateMoviesFound]);

    return {
        contextValue,
    };
}