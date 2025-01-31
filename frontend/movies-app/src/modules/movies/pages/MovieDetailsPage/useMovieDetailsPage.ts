import { useCallback, useState } from "react";
import { useNavigate } from "react-router";
import { getMovieUseCase } from "../../api/use-cases/get-movie-use-case";
import { MOVIES_PATH } from "../../constants";
import { Movie } from "../../models";

export const useMovieDetailsPage = () => {
    const [isLoading, setIsLoading] = useState(false);
    const [isFinished, setIsFinished] = useState(false);
    const [movie, setMovie] = useState<Movie>();
    const navigate = useNavigate();

    const getMovie = useCallback(async (movieId: number) => {
        let result: Movie | undefined;

        setIsLoading(true);

        if (!movieId) navigate(MOVIES_PATH);

        result = await getMovieUseCase(movieId);

        setIsFinished(true);
        setMovie(result);
        setIsLoading(false);
    }, [setIsLoading, setMovie, navigate, setIsFinished]);

    return {
        isLoading,
        movie,
        isFinished,
        getMovie,
    };
}