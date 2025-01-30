import { useCallback, useContext, useEffect, useState } from "react";
import { getMoviesByNameUseCase } from "../../api/use-cases";
import { MovieContext } from "../../context/MovieContext/MovieContext";
import { Movie } from "../../models";

export const useMoviesPage = () => {
    const [isLoading, setIsLoading] = useState(false);
    const [movies, setMovies] = useState<Movie[]>([]);
    const [noMovieFound, setNoMovieFound] = useState<boolean>(false);
    const { searchMovieName, updateSearchMovieName, moviesFound, updateMoviesFound } = useContext(MovieContext);
    const [searchValue, setSearchValue] = useState('');

    const handleInput = (e: any) => {
        const fieldValue = e.nativeEvent.target.value;
        updateSearchMovieName(fieldValue);
    }
    const handleSearch = useCallback(async (searchValue?: string) => {
        if (!searchValue) return;

        let result: Movie[] = [];

        setIsLoading(true);

        if (searchValue) {
            result = await getMoviesByNameUseCase(searchValue);
        }

        setMovies(result);

        updateMoviesFound(result);
        setNoMovieFound(result?.length === 0);
        setIsLoading(false);
    }, [setIsLoading, setMovies, setNoMovieFound, updateMoviesFound]);

    useEffect(() => {
        if (!searchMovieName) return;

        setSearchValue(searchMovieName);
    }, [searchMovieName]);

    useEffect(() => {
        if (!moviesFound) return;

        setMovies(moviesFound);
    }, [moviesFound]);

    return {
        searchMovieName,
        isLoading,
        movies,
        noMovieFound,
        searchValue,
        handleInput,
        handleSearch,
        setMovies,
    };
}