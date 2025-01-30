import { PropsWithChildren } from "react";

type TProps = {
} & PropsWithChildren;

export const BasicContainer = ({ children }: TProps) => {
    return (
        <div className="min-w-[900px] justify-center mt-10 h-full">
            {children}
        </div>
    );
}