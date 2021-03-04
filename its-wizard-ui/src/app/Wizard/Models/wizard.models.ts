export class Step {
    id!: number;
    name!: string;
    items!: Item[];
}

export class Item{
  id!: number;
  title!: string;
  description!: string;
  stepId!: number;
}
