import { useCallback, useState } from "react";
import { getMoviesByNameUseCase } from "../../api/use-cases";
import { Movie } from "../../models";

export const useMoviesPage = () => {
    const [isLoading, setIsLoading] = useState(false);
    const [movies, setMovies] = useState<Movie[]>([]);
    const [noMovieFound, setNoMovieFound] = useState<boolean>(false);

    const handleSearch = useCallback(async (searchValue: string) => {
        let result: Movie[] = [];

        setIsLoading(true);

        if (searchValue) {
            result = await getMoviesByNameUseCase(searchValue);
        }

        setMovies(result);
        setNoMovieFound(result?.length === 0);
        setIsLoading(false);
    }, [setIsLoading, setMovies, setNoMovieFound]);

    return {
        isLoading,
        movies,
        noMovieFound,
        handleSearch,
    };
}